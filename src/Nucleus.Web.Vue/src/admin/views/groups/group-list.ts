import NucleusComponentBase from "@/shared/application/nucleus-component-base";
import { Component, Watch } from "vue-property-decorator";

@Component
export default class GroupListComponent extends NucleusComponentBase {
  public refs = this.$refs as any;
  public loading = true;
  public pagination = {};
  public search = "";
  public dialog = false;
  public formTitle = "";
  public errors: INameValueDto[] = [];
  public allRoles: IRoleDto[] = [];
  public isEdit = false;
  public selectAll = false;

  get headers() {
    return [
      { text: this.$t("GroupName"), value: "userName" },
      { text: this.$t("Actions"), value: "", sortable: false }
    ];
  }

  public createOrUpdateGroupInput = {
    grantedRoleIds: [],
    group: {} as IGroupDto
  } as ICreateOrUpdateGroupInput;

  public pagedListOfGroupListDto: IPagedList<IPagedListInput> = {
    totalCount: 0,
    items: []
  };

  @Watch("pagination")
  public onPaginationChanged() {
    this.getGroups();
  }

  @Watch("search")
  public onSearchChanged() {
    this.getGroups();
  }

  public mounted() {
    this.getGroups();
  }

  public editGroup(id: string) {
    this.dialog = true;
    this.formTitle = id
      ? this.$t("EditGroup").toString()
      : this.$t("NewGroup").toString();
    this.isEdit = id ? true : false;
    this.errors = [];
    this.nucleusService
      .get<IGetGroupForCreateOrUpdateOutput>(
        "/api/group/GetGroupForCreateOrUpdate?id=" + id
      )
      .then(response => {
        const result = response.content as IGetGroupForCreateOrUpdateOutput;
        this.allRoles = result.allRoles;
        this.createOrUpdateGroupInput = {
          grantedRoleIds: result.grantedRoleIds,
          group: result.group
        };
      });
  }

  public deleteGroup(id: string) {
    this.swalConfirm(this.$t("AreYouSureToDelete").toString()).then(result => {
      if (result.value) {
        const query = "?id=" + id;

        this.nucleusService
          .delete("/api/group/deleteGroup" + query)
          .then(response => {
            if (!response.isError) {
              this.swalToast(2000, "success", this.$t("Successful").toString());
              this.getGroups();
            } else {
              this.swalAlert("error", response.errors.join("<br>"));
            }
          });
      }
    });
  }

  public save() {
    if (this.refs.form.validate()) {
      this.errors = [];
      this.nucleusService
        .post<void>("/api/group/createOrUpdateGroup", this
          .createOrUpdateGroupInput as ICreateOrUpdateGroupInput)
        .then(response => {
          if (!response.isError) {
            this.swalToast(2000, "success", this.$t("Successful").toString());
            this.dialog = false;
            this.getGroups();
          } else {
            this.errors = response.errors;
          }
        });
    }
  }

  public getGroups() {
    this.loading = true;
    const { sortBy, descending, page, rowsPerPage }: any = this.pagination;
    const groupListInput: IPagedListInput = {
      filter: this.search,
      pageIndex: page - 1,
      pageSize: rowsPerPage
    };

    if (sortBy) {
      groupListInput.sortBy = sortBy + (descending ? " desc" : "");
    }

    const query = "?" + this.queryString.stringify(groupListInput);
    this.nucleusService
      .get<IPagedList<IPagedListInput>>("/api/group/getGroups" + query, false)
      .then(response => {
        this.pagedListOfGroupListDto = response.content as IPagedList<
          IPagedListInput
        >;
        this.loading = false;
      });
  }

  public selectAllRoles() {
    this.createOrUpdateGroupInput.grantedRoleIds = [];
    if (this.selectAll) {
      this.createOrUpdateGroupInput.grantedRoleIds = this.allRoles.map(
        roles => roles.id
      ) as string[];
    }
  }
}
