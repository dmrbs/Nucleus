import NucleusComponentBase from '@/shared/application/nucleus-component-base';
import { Component, Watch } from 'vue-property-decorator';

@Component
export default class MeasurementListComponent extends NucleusComponentBase {
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
            { text: this.$t('MeasurementDegree'), value: 'Degree' },
            { text: this.$t('MeasurementDescription'), value: 'Description' },
            { text: this.$t('StartTime'), value: 'StartTime'},
            { text: this.$t('FinishTime'), value: 'FinishTime'},
            { text: this.$t('FlyNumber'), value: 'flyNumber'},
            { text: this.$t('Container'), value: 'container'}
        ];
    }

    public pagedListOfMeasurementListDto: IPagedList<IPagedListInput> = {
        totalCount: 0,
        items: []
    };

    @Watch('pagination')
    public onPaginationChanged() {
        this.getMeasurements();
    }

    @Watch('search')
    public onSearchChanged() {
        this.getMeasurements();
    }

    public mounted() {
        this.getMeasurements();
    }

    public getMeasurements() {
        this.loading = true;
        const { sortBy, descending, page, rowsPerPage }: any = this.pagination;
        const measurementListInput: IPagedListInput = {
            filter: this.search,
            pageIndex: page - 1,
            pageSize: rowsPerPage
        };

        if (sortBy) {
            measurementListInput.sortBy = sortBy + (descending ? ' desc' : '');
        }

        const query = '?' + this.queryString.stringify(measurementListInput);
        this.nucleusService.get<IPagedList<IPagedListInput>>('/api/measurement/getMeasurements' + query, false).then((response) => {
            this.pagedListOfMeasurementListDto = response.content as IPagedList<IPagedListInput>;
            this.loading = false;
        });
    }


}