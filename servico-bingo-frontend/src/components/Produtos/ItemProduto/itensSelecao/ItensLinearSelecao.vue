<template>
  <div>
    <v-expansion-panels focusable>
      <v-expansion-panel v-for="(item, i) in obterItensArea" :key="i" class="mb-1">
        <v-expansion-panel-header>
          <h3> {{ item.nome }}</h3>
          <v-divider vertical class="mx-2"></v-divider>
          <h4>Tipo:<h5> {{ item.tipoItem.descricao }} </h5>
          </h4>
        </v-expansion-panel-header>
        <v-expansion-panel-content>
          <v-row>
            <v-col cols="4" sm="4" md="4">
              <v-text-field type="number" v-model="quantidade" label="Quantidade de itens*" required></v-text-field>
            </v-col>

            <v-col cols="4" sm="6" md="4">
              <v-text-field label="Valor adicional" type="number" v-model="valorAdicional" step="0.01" locale="pt-BR"
                prefix="R$" required
               ></v-text-field>
            </v-col>
            <v-col>
              <v-btn color="primary" class="mt-5" @click="selecionaItem(item)"
              :disabled="!quantidade || quantidade < 1 ">
                <v-icon dark>
                  mdi-plus
                </v-icon>
              </v-btn>
            </v-col>
          </v-row>
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
  </div>
</template>
<script lang="ts">
import { Dimencao } from "@/Model/Enum/DimencaoEnum";
import ItemModel from "@/Model/Itens/ItemModel";
import ItemProdutoModel from "@/Model/Produtos/ItemProdutoModel";
import { StoreNamespaces } from "@/store";

import { ProdutosActionTypes } from "@/store/Produtos/actions";
import { Vue, Component, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";

const item = namespace(StoreNamespaces.ITEM);
const produto = namespace(StoreNamespaces.PRODUTO);
@Component({
  components: {
  }
})
export default class ItensLinearSelecao extends Vue {

  @Prop()
  produtoId!: number;

  @Prop()
  public itensNaoAdicionados!: ItemModel[];
  
  @produto.Action(ProdutosActionTypes.SALVAR_ITEM_PRODUTO)
  private salvarItemProduto!:(itemProduto: ItemProdutoModel)=> Promise<void>;

  @item.State
  public itens!: ItemModel[];


public quantidade = 1;
public valorAdicional = 0;

  public get obterItensArea() {
    debugger
    const intens = this.itensNaoAdicionados.filter(i => i.dimencaoId === Dimencao.Comprimento);
    return intens;
  }
  private itemProduto = new ItemProdutoModel();

  public async selecionaItem(item: ItemModel) {
    this.itemProduto.itemId = item.id;
    this.itemProduto.produtoId =this.produtoId;
    this.itemProduto.valorAdicional = this.valorAdicional;
    this.itemProduto.quantidade = this.quantidade;
    await this.salvarItemProduto(this.itemProduto).then(()=>{
    });
  }


}
</script>