<template>
  <v-expansion-panels focusable>
    <v-expansion-panel v-for="categoria in categorias" :key="categoria.id" class="mb-2">
      <v-expansion-panel-header>  <h2>{{ categoria.descricao }}</h2></v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-row>
          <v-col cols="6">
            <edicao-categoria :categoria="categoria" @categoriaAlterada="alteracaoCategoria" ></edicao-categoria>
           
            <h3 class="text-center">Editar</h3></v-col>
            
          <v-col cols="6">
            <v-btn text @click="excluirCategoria(categoria.id)"><v-icon>mdi-trash-can-outline</v-icon> </v-btn>
            <h3 class="text-center">Escluir</h3>
          </v-col>
        </v-row>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import CategoriaModel from '@/Model/Itens/CategoriaModel';
import EdicaoCategoria from '@/components/Itens/Categoria/EditacaoCategoria.vue';
import { ItensActionTypes } from '@/store/Item/actions';
import { StoreNamespaces } from '@/store';
import { namespace } from 'vuex-class';

const item = namespace(StoreNamespaces.ITEM);
@Component({
  components: {
    EdicaoCategoria,
  }
})
export default class ListagemCategoria extends Vue {

 @item.State
 public categorias!: CategoriaModel[];
   
  @item.Action(ItensActionTypes.REMOVER_CATEGORIA_ITEM)
  public removerCategoriaItem!:(id: number) => Promise<any>;

  @item.Action(ItensActionTypes.OBTER_TIPOS_ITEM)
  public obterTiposItem!:() => Promise<any>;

  public alteracaoCategoria(categoria: CategoriaModel){
    this.categorias.filter(x=>x.id===categoria.id).map(c=>c =categoria);
  }

      public async excluirCategoria(id:number){
       await this.removerCategoriaItem(id).then(()=>{
        this.obterTiposItem();
       });
      }
}
</script>