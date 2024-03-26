<template>
  
    <div justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Criar Categoria</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome da categoria*"
                    required
                    v-model="itemEdicao.nome"
                  ></v-text-field>
                </v-col>
                
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Valor de compra"
                    hint="custo de compra do item"
                     v-model="itemEdicao.valorCompra"
                  ></v-text-field>
                </v-col>

                 <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Valor de venda"
                    hint="pretenção de venda do item"
                     v-model="itemEdicao.valorVenda"
                  ></v-text-field>
                </v-col>
               
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="editarItem(itemEdicao)" class="mt-8">
              Salvar Edição
            </v-btn>
            
            <v-btn color="blue" text @click="dialog = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
             <v-btn text  @click="dialog=true"><v-icon x-large>mdi-circle-edit-outline</v-icon> </v-btn>
       
    </div>
   
  
</template>


<script lang="ts">
import { Vue, Component,Prop } from "vue-property-decorator";
import TipoModel from "@/Model/Itens/TipoModel";
import { StoreNamespaces } from "@/store";
import { namespace } from "vuex-class";
import { ItensActionTypes } from "@/store/Item/actions";
import ItemModel from "@/Model/Itens/ItemModel";

const item = namespace(StoreNamespaces.ITEM);

@Component({})
export default class EdicaoItem extends Vue {
  public dialog = false;

 @item.Action(ItensActionTypes.EDITAR_ITEM)
  public editaItem!:(item: ItemModel) => Promise<any>;

  @Prop()
  public itemEdicao!: ItemModel;
  

  private async editarItem(item: ItemModel): Promise<any>{
       await this.editaItem(item).then(()=>{
           this.dialog = false;
        });
  }
}
</script>