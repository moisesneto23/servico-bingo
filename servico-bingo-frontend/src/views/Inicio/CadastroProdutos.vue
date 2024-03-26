<template>
  <div id="cadastroOrcamento">
    <v-tabs v-model="tab" class="mt-2" grow icons-and-text background-color="#9575CD" color="f2f2f2f">
      <v-tabs-slider></v-tabs-slider>

      <v-tab href="#tab-3">
        Produtos
        <v-icon>mdi-shape-square-plus</v-icon>
      </v-tab>
     

      <v-tab href="#tab-2">
        Tipos
        <v-icon>mdi-view-grid-plus-outline</v-icon>
      </v-tab>

      <v-tab href="#tab-1" >
        Categorias
        <v-icon>mdi-format-list-group-plus</v-icon>
      </v-tab>
    
    </v-tabs>

    <v-tabs-items v-model="tab" data-app style="background-color: #f2f2f2;">

      <v-tab-item value="tab-3">
        <div>
          <v-card-text>
            <listagem-produto></listagem-produto>
          </v-card-text>
          <cadastro-produto></cadastro-produto>
        </div>
      </v-tab-item>
     

      <v-tab-item value="tab-2">
        <div>
          <v-card-text>
            <listagem-tipo-produto></listagem-tipo-produto>
          </v-card-text>
          <cadastro-tipo-produto></cadastro-tipo-produto>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-1">
        <div>
          <v-card-text>
            <listagem-categoria-produto></listagem-categoria-produto>
          </v-card-text>
          <cadastro-categoria-produto></cadastro-categoria-produto>
        </div>
      </v-tab-item>

    </v-tabs-items>


  </div>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import CadastroCategoriaProduto from "@/components/Produtos/CategoriaProduto/CadastroCategoriaProduto.vue";
import CadastroTipoProduto from '@/components/Produtos/TipoProduto/CadastroTipoProduto.vue';
import ListagemCategoriaProduto from '@/components/Produtos/CategoriaProduto/ListagemCategoriaProduto.vue'
import ListagemTipoProduto from '@/components/Produtos/TipoProduto/ListagemTipoProduto.vue'
import ListagemProduto from '@/components/Produtos/Produto/ListagemProduto.vue';
import CadastroProduto from '@/components/Produtos/Produto/CadastroProduto.vue';
import { ProdutosActionTypes } from "@/store/Produtos/actions";
import { namespace } from "vuex-class";
import { StoreNamespaces } from "@/store/namespaces";
import { ItensActionTypes } from "@/store/Item/actions";
const produto = namespace(StoreNamespaces.PRODUTO);
const item = namespace(StoreNamespaces.ITEM);
@Component({
  components: {
    CadastroCategoriaProduto,
    CadastroTipoProduto,
    ListagemCategoriaProduto,
    ListagemTipoProduto,
    ListagemProduto,
    CadastroProduto
  },
})
export default class CadastroProdutos extends Vue {
  public tab = null;
  @produto.Action(ProdutosActionTypes.OBTER_CATEGORIAS_PRODUTO)
    public obterCategoriassProduto!:() => Promise<any>;

      @produto.Action(ProdutosActionTypes.OBTER_ITEMS_PRODUTO)
    public obterItenssProduto!:() => Promise<any>;

      @produto.Action(ProdutosActionTypes.OBTER_PRODUTOS)
    public obterProdutos!:() => Promise<any>;

      @item.Action(ItensActionTypes.OBTER_ITENS)
    public obterItens!:() => Promise<any>;

      @produto.Action(ProdutosActionTypes.OBTER_TIPOS_PRODUTO)
    public obterTiposProduto!:() => Promise<any>;
  public async mounted(){
    await this.obterCategoriassProduto();
    await this.obterItenssProduto();
    await this.obterProdutos();
    await this.obterTiposProduto();
    await this.obterItens();
}
}

</script>
<style scoped>
#cadastroOrcamento{
  background-color: rgb(60, 172, 224);
}
</style>