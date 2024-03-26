<template>
  <v-expansion-panels focusable>
    <v-expansion-panel v-for="(item, i) in obterItensUnitarios" :key="i" class="mb-2">
      <v-expansion-panel-header><h3>  {{ item.nome }}</h3>
        <v-divider vertical class="mx-2"></v-divider> 
         <h4>Categoria: <h5> {{ item.tipoItem.descricao}} </h5></h4> </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-row>
          <v-col cols="6">
            <edicao-item :itemEdicao="item" ></edicao-item>
            <h3 class="text-center">Editar</h3></v-col>
          <v-col cols="6">
            <v-btn text><v-icon x-large @click="excluirItem(item.id)">mdi-trash-can-outline</v-icon> </v-btn>
            <h3 class="text-center">Escluir</h3>
          </v-col>
        </v-row>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>
<script lang="ts">
import { Dimencao } from "@/Model/Enum/DimencaoEnum";
import ItemModel from "@/Model/Itens/ItemModel";
import { StoreNamespaces } from "@/store";
import { ItensActionTypes } from "@/store/Item/actions";
import { Vue, Component } from "vue-property-decorator";
import { namespace } from "vuex-class";
import EdicaoItem from "../EdicaoItem.vue"; 

const item = namespace(StoreNamespaces.ITEM);
@Component({
  components: {
    EdicaoItem,
  }
  })
export default class ListaUnidade extends Vue {
  
  @item.Action(ItensActionTypes.REMOVER_ITEM)
  public removerItem!:(id: number) => Promise<void>

  public get obterItensUnitarios(){
    const intens = this.itens.filter(i=>i.dimencaoId === Dimencao.Unidade);
    return intens;
  }
 public async excluirItem(id: number){
    await this.removerItem(id);
 }
  @item.State
  public itens!: ItemModel[];

}
</script>