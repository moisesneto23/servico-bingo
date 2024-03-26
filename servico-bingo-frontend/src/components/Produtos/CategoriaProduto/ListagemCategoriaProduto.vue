<template>
  <v-expansion-panels focusable>
    <v-expansion-panel v-for="categoriaProduto in categoriasProduto" :key="categoriaProduto.id" class="mb-2">
      <v-expansion-panel-header>  <h1>{{ categoriaProduto.descricao }}</h1></v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-row>
          <v-col cols="6">
            <edicao-categoria-produto :categoriaProduto="categoriaProduto" ></edicao-categoria-produto>
           
            <h3 class="text-center">Editar</h3></v-col>
            
          <v-col cols="6">
            <v-btn text @click="excluirCategoriaProduto(categoriaProduto.id)"><v-icon>mdi-trash-can-outline</v-icon> </v-btn>
            <h3 class="text-center">Escluir</h3>
          </v-col>
        </v-row>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import EdicaoCategoriaProduto from '@/components/Produtos/CategoriaProduto/EditacaoCategoriaProduto.vue';

import { StoreNamespaces } from '@/store';
import { namespace } from 'vuex-class';
import CategoriaProdutoModel from "@/Model/Produtos/CategoriaProdutoModel";
import { ProdutosActionTypes } from "@/store/Produtos/actions";

const produto = namespace(StoreNamespaces.PRODUTO);
@Component({
  components: {
    EdicaoCategoriaProduto,
  }
})
export default class ListagemCategoriaProdutoProduto extends Vue {

 @produto.State
 public categoriasProduto!: CategoriaProdutoModel[];
  
  @produto.Action(ProdutosActionTypes.OBTER_CATEGORIAS_PRODUTO)
  public obterTodasCategoriasProduto!:() => Promise<any>;

    @produto.Action(ProdutosActionTypes.OBTER_TIPOS_PRODUTO)
  public obterTiposProduto!:() => Promise<any>;
   
  @produto.Action(ProdutosActionTypes.REMOVER_CATEGORIA_PRODUTO)
  public removerCategoriaProduto!:(id: number) => Promise<any>;

  public mounted(){
    this.obterTodasCategoriasProduto();
  }

  public async excluirCategoriaProduto(id:number){
    await this.removerCategoriaProduto(id).then(()=>{
      this.obterTiposProduto;
    });
  }
}
</script>