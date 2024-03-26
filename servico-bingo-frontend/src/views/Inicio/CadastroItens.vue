<template>
  <div id="cadastroOrcamento">
    <v-tabs v-model="tab" grow icons-and-text background-color="#4B5" color="black">
      <v-tabs-slider></v-tabs-slider>

      <v-tab href="#tab-1">
        Categorias
        <v-icon>mdi-format-list-group-plus</v-icon>
      </v-tab>

      <v-tab href="#tab-2">
        Tipos
        <v-icon>mdi-view-grid-plus-outline</v-icon>
      </v-tab>

      <v-tab href="#tab-3">
        Itens
        <v-icon>mdi-shape-square-plus</v-icon>
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab" data-app  style="background-color: #f2f2f2;">

      <v-tab-item value="tab-1">
        <div>
          <v-card-text>
            <listagem-categoria></listagem-categoria>
          </v-card-text>
          <cadastro-categoria></cadastro-categoria>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-2">
        <div>
          <v-card-text>
            <listagem-tipo></listagem-tipo>
          </v-card-text>
          <cadastro-tipo></cadastro-tipo>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-3">
        <div>
          <v-card-text>
            <listagem-item></listagem-item>
          </v-card-text>
        </div>
      </v-tab-item>

    </v-tabs-items>


  </div>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import CadastroCategoria from "@/components/Itens/Categoria/CadastroCategoria.vue";
import CadastroTipo from '@/components/Itens/Tipo/CadastroTipo.vue';
import ListagemCategoria from '@/components/Itens/Categoria/ListagemCategoria.vue'
import ListagemTipo from '@/components/Itens/Tipo/ListagemTipo.vue'
import ListagemItem from '@/components/Itens/Item/ListagemItem.vue';
import { StoreNamespaces } from "@/store/namespaces";
import { namespace } from "vuex-class";
import { ItensActionTypes } from "@/store/Item/actions";

const item = namespace(StoreNamespaces.ITEM);
@Component({
  components: {
    CadastroCategoria,
    CadastroTipo,
    ListagemCategoria,
    ListagemTipo,
    ListagemItem,
  },
})
export default class CadastroOrcamento extends Vue {
  public tab = null;

  @item.Action(ItensActionTypes.OBTER_CATEGORIAS_ITEM)
  public obterTodasCategoriasItem!:() => Promise<any>;

    @item.Action(ItensActionTypes.OBTER_TIPOS_ITEM)
  public obterTodosTiposItem!:() => Promise<any>;

    @item.Action(ItensActionTypes.OBTER_ITENS)
  public obterTodosItens!:() => Promise<any>;

    public async mounted(){
     this.obterTodasCategoriasItem();
     this.obterTodosTiposItem();
     this.obterTodosItens();
  }
}
</script>
<style scoped>
#cadastroOrcamento{
  background-color: rgb(186, 186, 186);
}
</style>