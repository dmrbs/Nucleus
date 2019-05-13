import NucleusComponentBase from '@/shared/application/nucleus-component-base';
import { Component, Watch } from 'vue-property-decorator';

@Component
export default class TagListComponent extends NucleusComponentBase {
    public refs = this.$refs as any;
    public loading = true;
    public pagination = {};
    public search = '';
    public dialog = false;
    public formTitle = '';
    public errors: INameValueDto[] = [];
    public allRoles: IRoleDto[] = [];
    public isEdit = false;
    public selectAll = false;
    //allTags: IPermissionDto[];
    //allTags: any;

    get headers() {
        return [
            { text: this.$t('TagSerialNumber'), value: 'userName' },
            { text: this.$t('TagDescription'), value: 'email' },
            { text: this.$t('Actions'), value: '', sortable: true }
        ];
    }

    public createOrUpdateTagInput = {
        grantedRoleIds: [],
        tag: {} as ITagDto
    } as ICreateOrUpdateTagInput;

    public pagedListOfTagListDto: IPagedList<IPagedListInput> = {
        totalCount: 0,
        items: []
    };

    @Watch('pagination')
    public onPaginationChanged() {
        this.getTags();
    }

    @Watch('search')
    public onSearchChanged() {
        this.getTags();
    }

    public mounted() {
        this.getTags();
    }

    public editTag(id: string) {
        this.dialog = true;
        this.formTitle = id ? this.$t('EditTag').toString() : this.$t('NewTag').toString();
        this.isEdit = id ? true : false;
        this.errors = [];
        this.nucleusService.get<IGetTagForCreateOrUpdateOutput>('/api/tag/GetTagForCreateOrUpdate?id=' + id)
            .then((response) => {
                const result = response.content as IGetTagForCreateOrUpdateOutput;
                this.allRoles = result.allRoles;
                this.createOrUpdateTagInput = {
                    grantedRoleIds: result.grantedRoleIds,
                    tag: result.tag
                };
            });
    }

    public deleteTag(id: string) {
        this.swalConfirm(this.$t('AreYouSureToDelete').toString())
            .then((result) => {
                if (result.value) {
                    const query = '?id=' + id;

                    this.nucleusService.delete('/api/tag/deleteTag' + query)
                        .then((response) => {
                            if (!response.isError) {
                                this.swalToast(2000, 'success', this.$t('Successful').toString());
                                this.getTags();
                            } else {
                                this.swalAlert('error', response.errors.join('<br>'));
                            }
                        });
                }
            });
    }

    public save() {
        if (this.refs.form.validate()) {
            this.errors = [];
            this.nucleusService.post<void>('/api/tag/createOrUpdateTag',
                this.createOrUpdateTagInput as ICreateOrUpdateTagInput)
                .then((response) => {
                    if (!response.isError) {
                        this.swalToast(2000, 'success', this.$t('Successful').toString());
                        this.dialog = false;
                        this.getTags();
                    } else {
                        this.errors = response.errors;
                    }
                });
        }
    }

    public getTags() {
        this.loading = true;
        const { sortBy, descending, page, rowsPerPage }: any = this.pagination;
        const tagListInput: IPagedListInput = {
            filter: this.search,
            pageIndex: page - 1,
            pageSize: rowsPerPage
        };

        if (sortBy) {
            tagListInput.sortBy = sortBy + (descending ? ' desc' : '');
        }

        const query = '?' + this.queryString.stringify(tagListInput);
        this.nucleusService.get<IPagedList<IPagedListInput>>('/api/tag/getTags' + query, false).then((response) => {
            this.pagedListOfTagListDto = response.content as IPagedList<IPagedListInput>;
            this.loading = false;
        });
    }

    public selectAllRoles() {
        this.createOrUpdateTagInput.grantedRoleIds = [];
        if (this.selectAll) {
            this.createOrUpdateTagInput.grantedRoleIds = ((this.allRoles.map((roles) => roles.id)) as string[]);
        }
    }
}