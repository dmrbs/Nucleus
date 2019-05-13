interface IGetMeasurementForCreateOrUpdateOutput {
    measurement: IMeasurementDto;
    allRoles: IPermissionDto[];
    grantedRoleIds: string[]
}