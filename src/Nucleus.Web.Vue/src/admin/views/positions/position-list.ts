import NucleusComponentBase from '@/shared/application/nucleus-component-base';
import { Component, Watch } from 'vue-property-decorator';

@Component
export default class PositionListComponent extends NucleusComponentBase {
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

    get headers() {
        return [
            { text: this.$t('PositionName'), value: 'userName' },
            { text: this.$t('Actions'), value: '', sortable: false }
        ];
    }

    public createOrUpdatePositionInput = {
        grantedRoleIds: [],
        position: {} as IPositionDto
    } as ICreateOrUpdatePositionInput;

    public pagedListOfPositionListDto: IPagedList<IPagedListInput> = {
        totalCount: 0,
        items: []
    };

    @Watch('pagination')
    public onPaginationChanged() {
        this.getPositions();
    }

    @Watch('search')
    public onSearchChanged() {
        this.getPositions();
    }

    public mounted() {
        this.getPositions();
    }

    public editPosition(id: string) {
        this.dialog = true;
        this.formTitle = id ? this.$t('EditPosition').toString() : this.$t('NewPosition').toString();
        this.isEdit = id ? true : false;
        this.errors = [];
        this.nucleusService.get<IGetPositionForCreateOrUpdateOutput>('/api/position/GetPositionForCreateOrUpdate?id=' + id)
            .then((response) => {
                const result = response.content as IGetPositionForCreateOrUpdateOutput;
                this.allRoles = result.allRoles;
                this.createOrUpdatePositionInput = {
                    grantedRoleIds: result.grantedRoleIds,
                    position: result.position
                };
            });
    }

    public deletePosition(id: string) {
        this.swalConfirm(this.$t('AreYouSureToDelete').toString())
            .then((result) => {
                if (result.value) {
                    const query = '?id=' + id;

                    this.nucleusService.delete('/api/position/deletePosition' + query)
                        .then((response) => {
                            if (!response.isError) {
                                this.swalToast(2000, 'success', this.$t('Successful').toString());
                                this.getPositions();
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
            this.nucleusService.post<void>('/api/position/createOrUpdatePosition',
                this.createOrUpdatePositionInput as ICreateOrUpdatePositionInput)
                .then((response) => {
                    if (!response.isError) {
                        this.swalToast(2000, 'success', this.$t('Successful').toString());
                        this.dialog = false;
                        this.getPositions();
                    } else {
                        this.errors = response.errors;
                    }
                });
        }
    }

    public getPositions() {
        this.loading = true;
        const { sortBy, descending, page, rowsPerPage }: any = this.pagination;
        const positionListInput: IPagedListInput = {
            filter: this.search,
            pageIndex: page - 1,
            pageSize: rowsPerPage
        };

        if (sortBy) {
            positionListInput.sortBy = sortBy + (descending ? ' desc' : '');
        }

        const query = '?' + this.queryString.stringify(positionListInput);
        this.nucleusService.get<IPagedList<IPagedListInput>>('/api/position/getPositions' + query, false).then((response) => {
            this.pagedListOfPositionListDto = response.content as IPagedList<IPagedListInput>;
            this.loading = false;
        });
    }

    public selectAllRoles() {
        this.createOrUpdatePositionInput.grantedRoleIds = [];
        if (this.selectAll) {
            this.createOrUpdatePositionInput.grantedRoleIds = ((this.allRoles.map((roles) => roles.id)) as string[]);
        }
    }
}