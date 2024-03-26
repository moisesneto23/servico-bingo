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
                    v-model="exibeCategoria.descricao"
                  ></v-text-field>
                </v-col>
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="processarEdicao(exibeCategoria)" class="mt-8">
              Salvar
            </v-btn>
            
            <v-btn color="blue" text @click="dialog = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
       <v-btn text @click="dialog=true">
              <v-icon>mdi-circle-edit-outline</v-icon> 
              </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import { Vue, Component,Prop } from "vue-property-decorator";
import CategoriaModel from "@/Model/Itens/CategoriaModel";
import { namespace } from "vuex-class";
import { StoreNamespaces } from "@/store";
import { ItensActionTypes } from "@/store/Item/actions";

const item = namespace(StoreNamespaces.ITEM);
@Component({})
export default class EdicaoCategoria extends Vue {

  @item.Action(ItensActionTypes.EDITAR_CATEGORIA_ITEM)
  public editarCategoriasItem!:(categoria: CategoriaModel) => Promise<any>;

  @item.Action(ItensActionTypes.OBTER_TIPOS_ITEM)
  public obterTiposItem!:() => Promise<any>;
  public dialog = false;

  @Prop()
  private categoria!: CategoriaModel;
  public get exibeCategoria(){
    return this.categoria;
  }
  public processarEdicao(categoria: CategoriaModel){
    this.editarCategoriasItem(categoria).then(()=>{
      this.dialog = false; 
      this.obterTiposItem();
      this.$emit('categoriaAlterada',this.categoria);
    });
  }

}
</script>