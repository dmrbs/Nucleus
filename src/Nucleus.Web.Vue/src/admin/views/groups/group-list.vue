<template>
    <div>
        <v-toolbar flat color="white">
            <v-toolbar-title>{{$t('Groups')}}</v-toolbar-title>
            <v-divider class="mx-2"
                       inset
                       vertical>
            </v-divider>
            <v-spacer></v-spacer>
            <v-text-field v-model="search"
                          append-icon="search"
                          :label="$t('Search')"
                          single-line
                          hide-details>
            </v-text-field>
            <v-spacer></v-spacer>
            <v-btn v-if="nucleus.auth.isGranted('Permissions_User_Create')" @click="editUser()" color="primary" dark class="mb-2">{{$t('NewGroup')}}</v-btn>
            <v-dialog v-model="dialog" max-width="500px">
                <v-card>
                    <v-card-title>
                        <span class="headline">{{ formTitle }}</span>
                    </v-card-title>

                    <v-card-text>
                        <div v-for="error in errors" :key="error.name">
                            <v-alert :value="true" type="error">
                                {{$t(error.name)}}
                            </v-alert>
                        </div>
                        <v-form ref="form" @keyup.native.enter="save">
                            <v-text-field name="groupName" :label="$t('GroupName')" type="text"
                                          v-model="createOrUpdateUserInput.user.groupName"
                                          :rules="[requiredError]"></v-text-field>
                          
                        </v-form>
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" flat @click="dialog = false">{{$t('Cancel')}}</v-btn>
                        <v-btn color="blue darken-1" flat @click="save">{{$t('Save')}}</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-toolbar>

        <v-data-table :headers="headers"
                      :items="pagedListOfUserListDto.items"
                      :pagination.sync="pagination"
                      :total-items="pagedListOfUserListDto.totalCount"
                      :loading="loading"
                      class="elevation-1">
            <template slot="items" slot-scope="props">
                <td>{{ props.item.userName }}</td>
                <td class="justify-center layout px-0">
                    <v-icon v-if="nucleus.auth.isGranted('Permissions_User_Update')" small
                            class="mr-2"
                            @click="editUser(props.item.id)">
                        edit
                    </v-icon>
                    <v-icon v-if="nucleus.auth.isGranted('Permissions_User_Delete')" small
                            @click="deleteUser(props.item.id)">
                        delete
                    </v-icon>
                </td>
            </template>
            <template slot="no-data" v-if="!loading">
                <v-alert :value="true" color="error" icon="warning">
                    {{$t('NothingToDisplay')}}
                </v-alert>
            </template>
        </v-data-table>
    </div>
</template>

<script src="./group-list.ts"></script>

<style>

</style>
