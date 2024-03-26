<template>
  <v-expansion-panels focusable>
    <v-expansion-panel v-for="tipo in tipos" :key="tipo.id" class="mb-2">
      <v-expansion-panel-header> <h3>  {{ tipo.descricao }}</h3> 
        <v-divider vertical class="mx-2"></v-divider> 
        <h4>Categoria: <h5>{{ tipo.categoriaItem.descricao}}</h5>  </h4> </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-row>
           <v-col cols="6">
            <edicao-tipo :tipo="tipo" ></edicao-tipo>
           
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
import TipoModel from "@/Model/Itens/TipoModel";
import EdicaoTipo from '@/components/Itens/Tipo/EdicaoTipo.vue'
import { StoreNamespaces } from "@/store";
import { ItensActionTypes } from "@/store/Item/actions";
import { namespace } from "vuex-class";

const item = namespace(StoreNamespaces.ITEM);
@Component({
  components:{
    EdicaoTipo,
  }
})
export default class ListagemTipo extends Vue {

  @item.Action(ItensActionTypes.REMOVER_TIPO_ITEM)
  public removerTipoItem!:(id: number) => Promise<any>;

  @item.Action(ItensActionTypes.OBTER_ITENS)
  public obterItens!:() => Promise<any>;

  @item.State
  public tipos!: TipoModel[];

 public async excluirTipo(id: number){
    await this.removerTipoItem(id).then(()=>{
      this.obterItens();
    });
 }
  
}
</script>