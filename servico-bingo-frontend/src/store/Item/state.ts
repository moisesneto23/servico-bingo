import CategoriaModel from '@/Model/Itens/CategoriaModel';
import  TipoModel  from '@/Model/Itens/TipoModel';
import ItemModel from '@/Model/Itens/ItemModel';


export class ItemState {
  public itens?: ItemModel[];
  public tipos?: TipoModel[] ;
  public categorias?: CategoriaModel[] ;

}

export const state: ItemState = {
  itens: [],
  tipos: [],
  categorias: [],
};
