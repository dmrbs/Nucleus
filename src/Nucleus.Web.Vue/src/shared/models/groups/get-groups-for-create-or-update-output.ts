interface IGetGroupForCreateOrUpdateOutput {
    group: IGroupDto;
    allRoles: IPermissionDto[];
    grantedRoleIds: string[]
}