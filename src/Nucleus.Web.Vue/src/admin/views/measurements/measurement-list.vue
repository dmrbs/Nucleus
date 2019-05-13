<template>
    <div>
        <v-toolbar flat color="white">
            <v-toolbar-title>{{$t('Measurements')}}</v-toolbar-title>
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
        </v-toolbar>

        <v-data-table :headers="headers"
                      :items="pagedListOfMeasurementListDto.items"
                      :pagination.sync="pagination"
                      :total-items="pagedListOfMeasurementListDto.totalCount"
                      :loading="loading"
                      class="elevation-1">
            <template slot="items" slot-scope="props">
                <td>deneme</td>
                <td>deneme</td>
                <td>deneme</td>
                <td>deneme</td>
                <td>deneme</td>
                <td>deneme</td>

                <td class="justify-center layout px-0">
                    <v-icon v-if="nucleus.auth.isGranted('Permissions_Measurement_Update')" small
                            class="mr-2"
                            @click="editMeasurement(props.item.id)">
                        edit
                    </v-icon>
                    <v-icon v-if="nucleus.auth.isGranted('Permissions_Measurement_Delete')" small
                            @click="deleteMeasurement(props.item.id)">
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

<script src="./measurement-list.ts"></script>
