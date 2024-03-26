<template>
  <v-expansion-panels focusable>
    <v-expansion-panel v-for="tipo in tiposProduto" :key="tipo.id" class="mb-2">
      <v-expansion-panel-header> <h3>  {{ tipo.descricao }}</h3>
        <v-divider vertical class="mx-2"></v-divider> 
         <h4>Categoria: <h5>{{ tipo.categoriaProduto.descricao}}</h5> </h4> </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-row>
           <v-col cols="6">
            <edicao-tipo-produto :tipoProduto="tipo" ></edicao-tipo-produto>
           
            <h3 class="text-center">Editar</h3></v-col>
            
          <v-col cols="6">
            <v-btn text @click="excluirTipo(tipo.id)"><v-icon>mdi-trash-can-outline</v-icon> </v-btn>
            <h3 class="text-center">Escluir</h3>
          </v-col>
        </v-row>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>
<script lang="ts">

import { Vue, Component } from "vue-property-decorator";
import EdicaoTipoProduto from '@/components/Produtos/TipoProduto/EdicaoTipoProduto.vue'
import { StoreNamespaces } from "@/store";
import { namespace } from "vuex-class";
import { ProdutosActionTypes } from "@/store/Produtos/actions";
import TipoProdutoModel from "@/Model/Produtos/TipoProdutoModel";

const produto = namespace(StoreNamespaces.PRODUTO);
@Component({
  components:{
    EdicaoTipoProduto,
  }
})
export default class ListagemTipoProduto extends Vue {
  
  @produto.Action(ProdutosActionTypes.OBTER_TIPOS_PRODUTO)
  public obterTodostiposProduto!:() => Promise<any>;

    @produto.Action(ProdutosActionTypes.OBTER_PRODUTOS)
  public obterProdutos!:() => Promise<any>;

  @produto.Action(ProdutosActionTypes.REMOVER_TIPO_PRODUTO)
  public removerTipoProduto!:(id: number) => Promise<any>;

  @produto.State
  public tiposProduto!: TipoProdutoModel[];

  public async mounted(){
    await this.obterTodostiposProduto();
  }
 public async excluirTipo(id: number){
    await this.removerTipoProduto(id).then(()=>{
      this.obterProdutos();
    });
 }
  
}
</script>