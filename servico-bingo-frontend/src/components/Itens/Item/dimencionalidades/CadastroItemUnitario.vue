<template>
  
    <div justify="center">
      <v-dialog v-model="dialogItem" persistent max-width="800px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Criar Item Unitario</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>

                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome do Item*"
                     v-model="item.nome"
                    required
                  ></v-text-field>
                </v-col>

                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Valor de compra"
                    hint="custo de compra do item"
                     v-model="item.valorCompra"
                  ></v-text-field>
                </v-col>

                 <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Valor de venda"
                    hint="pretenção de venda do item"
                     v-model="item.valorVenda"
                  ></v-text-field>
                </v-col>
               
                <v-col cols="12" sm="6">
                  <v-select
                    :items="descricaoTipos"
                    label="Selecione o tipo do item*"
                    required
                    v-model="select"
                  ></v-select>
                </v-col>
              
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="selecuinaIdSelect(), salvarItem()">
              Salvar
            </v-btn>
            <v-btn color="blue" text @click="dialogItem = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-btn @click="dialogItem=true" color="primary" :rounded="true">
        <v-icon>mdi-shape-square-plus</v-icon>
        Criar Item Unitario
      </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import { Dimencao } from "@/Model/Enum/DimencaoEnum";
import ItemModel from "@/Model/Itens/ItemModel";
import TipoModel from "@/Model/Itens/TipoModel";
import { StoreNamespaces } from "@/store";
import { ItensActionTypes } from "@/store/Item/actions";
import { Vue, Component } from "vue-property-decorator";
import { namespace } from "vuex-class";
const item = namespace(StoreNamespaces.ITEM);

@Component({})
export default class CadastroItemUnitario extends Vue {
  @item.Action(ItensActionTypes.SALVAR_ITEM)
  public salvaItem!:(item: ItemModel) => Promise<any>;

  @item.State
 private tipos!: TipoModel[];

  public item = new ItemModel();
  public selecuinaIdSelect(){
  this.idSelect = this.tipos.find(x=>x.descricao == this.select)?.id;
}
  public idSelect?: number;
  public select = '';
  public async salvarItem(){
    this.item.tipoItemId = this.idSelect || 0;
    this.item.dimencaoId = Dimencao.Unidade;
    this.item.direcaoCalculoId = 1;
    await this.salvaItem(this.item).then(()=>{
      this.dialogItem = false;
    })
  }

  public get descricaoTipos(){
    return this.tipos.map((c)=>c.descricao);
  }
  public dialogItem = false;
  public direcaoCalculo = ['altura','largura','profundidade']
}
</script>