<template>
  <FormList
      title="Carrinho"
      :field_customerID ="id"
      :tableHeader="tableheader"
      :tableItems="tableitems"
      >
  </FormList>
</template>

<script>
import FormList from "@/components/FormList.vue";
import api from '@/services/api.ts';

export default {
  name:"Cart",
   props: {
      id: { 
        type: Number
      }
  },
  components: {
    FormList
  },
  data() {
    return {
      tableheader: [
        { text: "Id.", value: "id", align:"start", divider:false, width: "15%", sortable: true },
        { text: "Descrição", value: "name",align:"start", divider:false, width: "25%", sortable: true },
        { text: "Qtd", value: "quantity",align:"start", divider:false, width: "15%", sortable: true },
        { text: "Preço", value: "unit_price",align:"start", divider:false, width: "15%", sortable: true },
        { text: "Total", value: "total_price",align:"start", divider:false, width: "15%", sortable: true },

        { text: "", value: "actions",align:"end", divider:false, width: "15%", sortable: true },
      ],
      tableitems:[]
    }
  },
  created () {
    this.id = this.$route.params.id;
  },
  methods:{
  }
}
</script>
