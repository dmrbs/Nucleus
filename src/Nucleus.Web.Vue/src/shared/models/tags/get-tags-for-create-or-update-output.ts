interface IGetTagForCreateOrUpdateOutput {
    tag: ITagDto;
    allRoles: IPermissionDto[];
    grantedRoleIds: string[]
}