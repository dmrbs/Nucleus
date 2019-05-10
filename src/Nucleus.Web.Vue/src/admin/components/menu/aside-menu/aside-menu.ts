import NucleusComponentBase from "@/shared/application/nucleus-component-base";
import { Component } from "vue-property-decorator";

@Component
export default class AsideMenuComponent extends NucleusComponentBase {
  public drawer = true;
  public isAdmin = false;

  get mainMenuItems() {
    return [{ icon: "home", text: this.$t("Home"), link: "/admin/home" }];
  }

  get adminMenuItems() {
    return [
      { icon: "person", text: this.$t("Users"), link: "/admin/user-list" },
      { icon: "work", text: this.$t("Roles"), link: "/admin/role-list" },
      { icon: "group", text: this.$t("Groups"), link: "/admin/group-list" },
      { icon: "info", text: this.$t("Positions"), link: "/admin/position-list" },
      { icon: "tag", text: this.$t("Tags"), link: "/admin/tag-list" },
      { icon: "expand", text: this.$t("Measurements"), link: "/admin/measurement-list" }
      
    ];
  }

  public mounted() {
    this.$root.$on("drawerChanged", () => {
      this.drawer = !this.drawer;
    });
  }
}
