interface IGetPositionForCreateOrUpdateOutput {
    position: IPositionDto;
    allRoles: IPermissionDto[];
    grantedRoleIds: string[]
}