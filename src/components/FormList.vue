<template>
  <sidebar-layout-vue>
    <v-container class="fill-height flex-column">
        <v-card :width="800"
          height="100%"
          max-height="600"
          class="mx-auto"
          outilined
          elevation="3">
          <v-container>
            <!--CABEÇALHO-->
            <v-row dense>
              <v-col cols="12">
                <v-toolbar flat
                        rounded
                        dense
                        class="blue-grey lighten-4">
                  <v-toolbar-title class="font-weight-medium">{{title}}</v-toolbar-title> 
                </v-toolbar>
              </v-col>
            </v-row>
            <!--ITEMS-->
            <v-row dense>
              <v-col>
                <v-data-table no-data-text="Nenhum Registro Disponível"
                              no-results-text="Nenhum Registro Encontrado"
                              dense
                              fixed-header
                              height="352px"
                              class="elevation-3"
                              item-key="Id"
                              single-select
                              hide-default-footer
                              :headers="tableHeader"
                              :items="tableItems"
                              :items-per-page="10">
                  <template v-slot:item.actions="{item}">
                      <v-tooltip bottom color="primary">
                        <template v-slot:activator="{on, attrs}">
                          <v-icon small
                              color="primary"
                              v-bind="attrs"
                              v-on="on"
                              class="mr-2"
                              :disabled="false"
                              @click="onDeleteItem(item)">
                              mdi-delete
                          </v-icon>
                        </template>
                        <span>Excluir</span>
                      </v-tooltip>
                  </template>
                </v-data-table>
              </v-col>
            </v-row>
            <v-container>
              <v-row dense>
                <v-col cols="7"
                  style="display: inline-block">
                  <v-select label="Produtos"
                            v-model="field_produto"
                            item-value="id"
                            item-text="name"
                            :items="produtos"
                            return-object>
                  </v-select>
                </v-col>
                <v-col cols="2"
                  style="display: inline-block">
                  <v-text-field label="Quantidade"
                            v-model="field_quantidade"
                            type="number"
                            :value="field_quantidade = (field_quantidade == null) ? 0 :  field_quantidade">
                  </v-text-field>
                </v-col>
                <v-col cols="2"
                  style="display: inline-block">
                  <v-text-field label="Preço"
                            v-model="field_produto.price"
                            type="number"
                            :disabled = "true"
                            :value="field_produto.price = (field_produto.price == null) ? 0 :  field_produto.price">
                  </v-text-field>
                </v-col>
                <v-col cols="1">
                  <v-btn icon
                        color="primary"
                        @click="onInsertItem">
                        <v-icon>mdi-file-plus</v-icon>
                  </v-btn>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="7"
                  style="display: inline-block">
                  <v-text-field label="Observação"
                            v-model="field_obs"
                            :value="field_obs = (field_obs == null) ? '' :  field_obs">
                  </v-text-field>
                </v-col>
                <v-col cols="2"
                  style="display: inline-block">
                  <v-text-field label="Total Pedido"
                            v-model="field_total"
                            type="number"
                            :disabled="true"
                            :value="field_total = (field_total == null) ? 0 :  field_total">
                  </v-text-field>
                </v-col>
                <v-col cols="2">
                  
                  <v-btn color="success"
                        small
                        elevation="5"
                        style="margin: 0 15px"
                        @click="onSave">
                        <v-icon left> mdi-checkbox-marked-circle</v-icon>
                        Finalizar
                  </v-btn>
                </v-col>
              </v-row>
            </v-container>
            <v-row dense justify="center">
              <v-pagination v-if="pageCount>0"
                    v-model="pageNumber"
                    circle
                    prev-icon="mdi-menu-left"
                    next-icon="mdi-menu-right"
                    :length="pageCount"></v-pagination>
            </v-row>
          </v-container>
        </v-card>
    </v-container>
  </sidebar-layout-vue>
</template>

<script>
import SidebarLayoutVue from "@/layouts/SidebarLayout.vue";
import api from '@/services/api.ts';
import { watch } from 'vue';

export default {
  name:"FormList",
  components: {
    SidebarLayoutVue
  },
  props: {
      title: String,
      tableHeader: [],
      tableItems: [],
      field_customerID:0
  },
  data: () => ({
    field_produto: [],
    produtos: [],
    field_quantidade: 0,
    field_obs:"",
    field_total:0,
    pageCount: 0,
    pageNumber: 0,
    formOrders: {
      id:0,
      customerID: 0,
      total_order: 0,
      created_at: "",
      comments: "",
     
    },
    formOrdersProduct: [{
        orderID: 0,
        productID: 0,
        quantity: 0,
        created_at: "",
        unit_price: 0,
        total_price: 0,
      }]
    
  }),
  created() {
      this.getProducts();
  },
  methods:{
    async getProducts(){
      await api.get(`/Product`, this.formOrders)
            .then((response) => {
              this.produtos = response.data;
            })
            .catch((error) => {
              console.error(error.response)
            })
    },
    async onSave(){
     
      if(this.tableItems.length > 0){
          this.formOrders.id = 0;
          this.formOrders.customerID = this.field_customerID;
          this.formOrders.total_order = this.field_total;
          this.formOrders.comments = this.field_obs;
          await api.post(`/Orders`,this.formOrders)
                .then((response) => {
                  this.formOrders.id = response.data.id;
                })
                .catch((error) => {
                  console.error(error.response)
                })
          if(this.formOrders.id > 0){
            this.formOrdersProduct = [];
            for (var i = 0; i < this.tableItems.length; i++) {
                this.formOrdersProduct.push({
                  orderID: this.formOrders.id,
                  productID: this.tableItems[i].id,
                  quantity: this.tableItems[i].quantity,
                  created_at: "",
                  unit_price: this.tableItems[i].unit_price,
                  total_price: this.tableItems[i].total_price,
                })
            }
            await api.post(`/Order_Product`,this.formOrdersProduct)
                    .then((response) => {
                      console.log(response.data);
                    })
                    .catch((error) => {
                      console.error(error.response)
                    })     
          }

          //Limpa
          this.tableItems=[];
          this.field_produto= []
          this.field_quantidade = 0;
          this.field_obs = "";
          this.field_total = 0;
      }
    },
    onInsertItem(){
        console.log(this.field_customerID);
        if (this.validation() == true){
            this.tableItems.push({id:this.field_produto.id,
                              name:this.field_produto.name,
                              quantity:this.field_quantidade,
                              unit_price:this.field_produto.price,
                              total_price:this.field_quantidade * this.field_produto.price});
            this.field_total += this.field_quantidade * this.field_produto.price;
        }
    },
    onDeleteItem(item){
        this.field_total -= item.total_price;
        this.tableItems.splice(this.tableItems.findIndex(f => f==item),1);      
    },
    validation(){
        if(this.field_quantidade <= 0 || this.tableItems.findIndex(f => f.id==this.field_produto.id)>=0){
          return false;
        }
        return true;
    }
  },

}

</script>
