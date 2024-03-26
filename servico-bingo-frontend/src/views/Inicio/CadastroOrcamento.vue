<template>
  <div id="cadastroOrcamento">
    <v-tabs v-model="tab" grow icons-and-text background-color="#64B5">
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
        Produtos
        <v-icon>mdi-shape-square-plus</v-icon>
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab" data-app>

      <v-tab-item value="tab-1">
        <v-card>
          <v-card-text>
            <listagem-categoria></listagem-categoria>
          </v-card-text>
          <cadastro-categoria></cadastro-categoria>
        </v-card>
      </v-tab-item>

      <v-tab-item value="tab-2">
        <v-card>
          <v-card-text>
            <listagem-tipo></listagem-tipo>
          </v-card-text>
          <cadastro-tipo></cadastro-tipo>
        </v-card>
      </v-tab-item>

      <v-tab-item value="tab-3">
        <v-card>
          <v-card-text>
            <listagem-item></listagem-item>
          </v-card-text>
        </v-card>
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
@Component({
  components: {
    CadastroCategoria,
    CadastroTipo,
    ListagemCategoria,
    ListagemTipo,
    ListagemItem,
  },
})
export default class CadastroProdutos extends Vue {
  public tab = null;
}
</script>
<style scoped>
#cadastroOrcamento{
  background-color: rgb(186, 186, 186);
}
</style>