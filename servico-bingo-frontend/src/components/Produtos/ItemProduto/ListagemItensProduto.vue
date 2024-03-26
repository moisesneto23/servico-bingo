<template>
  <div id="cadastroOrcamento">
    <v-tabs v-model="tab" grow icons-and-text background-color="#9FA8" color="#4A148C">
      <v-tabs-slider></v-tabs-slider>

      <v-tab href="#tab-1">
        Unidade
        <v-icon>mdi-checkbox-blank-circle</v-icon>
      </v-tab>

      <v-tab href="#tab-2">
        Comprimento
        <v-icon>mdi-arrow-right-thin</v-icon>
      </v-tab>

      <v-tab href="#tab-3">
        Perimetro
        <v-icon>mdi-network-strength-outline</v-icon>
      </v-tab>

      <v-tab href="#tab-4">
        Area
        <v-icon>mdi-square-outline</v-icon>
      </v-tab>

      <v-tab href="#tab-5">
        Volume
        <v-icon>mdi-package-variant-closed</v-icon>
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab" data-app style="background-color: #f2f2f2;">

      <v-tab-item value="tab-1">
        <div>
          <v-card-text>
            <itens-unidade-selecao :itensNaoAdicionados="itensNaoAdicionados"
              :produtoId="produtoId"></itens-unidade-selecao>
          </v-card-text>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-2">
        <div>
          <v-card-text>
            <itens-linear-selecao :itensNaoAdicionados="itensNaoAdicionados"
              :produtoId="produtoId"></itens-linear-selecao>
          </v-card-text>

        </div>
      </v-tab-item>

      <v-tab-item value="tab-3">
        <div>
          <v-card-text>
            <itens-perimetro-selecao :itensNaoAdicionados="itensNaoAdicionados"
              :produtoId="produtoId"></itens-perimetro-selecao>
          </v-card-text>

        </div>
      </v-tab-item>

      <v-tab-item value="tab-4">
        <div>
          <v-card-text>
            <itens-area-selecao :itensNaoAdicionados="itensNaoAdicionados" :produtoId="produtoId"></itens-area-selecao>
          </v-card-text>

        </div>
      </v-tab-item>

      <v-tab-item value="tab-5">
        <div>
          <v-card-text>
            <itens-volume-selecao :itensNaoAdicionados="itensNaoAdicionados"
              :produtoId="produtoId"></itens-volume-selecao>
          </v-card-text>

        </div>
      </v-tab-item>
      <hr>
      <v-card>

        itens selecionados
        <v-card>
          <v-expansion-panel v-for="(item, i) in itensAdicionados" :key="i" class="mb-1" expand-icon="mdi-plus">

            <v-expansion-panel-header @click="removerItem(item)" expand-icon="mdi-minus"
              style="background-color: #f2f2f2;">
              <h3> {{ item.nome }}</h3>
              <v-divider vertical class="mx-2"></v-divider>
              <h4>Tipo:<h5> {{ item.tipoItem.descricao }} </h5>
              </h4>
            </v-expansion-panel-header>

          </v-expansion-panel>

        </v-card>
      </v-card>
    </v-tabs-items>


  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import ItensUnidadeSelecao from './itensSelecao/ItensUnidadeSelecao.vue';
import ItensLinearSelecao from './itensSelecao/ItensLinearSelecao.vue';
import ItensAreaSelecao from './itensSelecao/ItensAreaSelecao.vue';
import ItensVolumeSelecao from './itensSelecao/ItensVolumeSelecao.vue';
import ItensPerimetroSelecao from './itensSelecao/ItensPerimetroSelecao.vue';
import ItemModel from "@/Model/Itens/ItemModel";
import { ProdutosActionTypes } from "@/store/Produtos/actions";
import { StoreNamespaces } from "@/store/namespaces";
import { namespace } from "vuex-class";
import ItemProdutoModel from "@/Model/Produtos/ItemProdutoModel";

const produto = namespace(StoreNamespaces.PRODUTO);
const item = namespace(StoreNamespaces.ITEM);

@Component({
  components: {
    ItensUnidadeSelecao,
    ItensLinearSelecao,
    ItensAreaSelecao,
    ItensVolumeSelecao,
    ItensPerimetroSelecao,
  },
})
export default class ListagemItensProduto extends Vue {
  @Prop()
  public produtoId!: number;

  @produto.Action(ProdutosActionTypes.REMOVER_ITEM_PRODUTO)
  private removeItemProduto!: (id: number) => Promise<void>;

  @produto.State
  private itensProduto!: ItemProdutoModel[];

  @item.State
  public itens!: ItemModel[];

  public tab = null;
  public dialogoItemProduto = false;
  public itensSelecionados: ItemModel[] = [];


  public adicionaItemProdutoSelecao() {
    this.dialogoItemProduto = false;
  }
  public obterItensSelecionados(item: ItemModel) {
    this.itensSelecionados.push(item);
  }

  public get itensAdicionados(): ItemModel[] {
    let itensRetorno: ItemModel[] = [];
    this.itensProduto.forEach(itensProduto => {
      this.itens.forEach(item => {
        if (item.id === itensProduto.itemId &&
          itensProduto.produtoId === this.produtoId)
          itensRetorno.push(item);
      })
    });
    return itensRetorno;
  }

  public get itensNaoAdicionados(): ItemModel[] {
    let itensRetorno: ItemModel[] = [];
    for (const item of this.itens) {
    if (!this.itensProduto.some(itemProduto => itemProduto.itemId === item.id && this.produtoId === itemProduto.produtoId)) {
      itensRetorno.push(item);
    }
  }
      return itensRetorno;
  }

  verificaItemPertenceAoProduto(item: ItemModel, itemProduto: ItemProdutoModel): boolean {
    if (this.produtoId ===itemProduto.produtoId && item.id === itemProduto.itemId)
      return true;
    return false;
  }

  public async removerItem(item: ItemModel) {
    const itemProduto = this.itensProduto.find(x => x.itemId === item.id && x.produtoId === this.produtoId);
    if (itemProduto !== undefined) {
      await this.removeItemProduto(itemProduto.id).then();
    }
  }
}
</script>
<style scoped>#cadastroOrcamento {
  background-color: rgb(186, 186, 186);
}</style>