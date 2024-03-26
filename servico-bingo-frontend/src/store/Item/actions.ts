import CategoriaModel  from '@/Model/Itens/CategoriaModel';
import  ItemModel  from '@/Model/Itens/ItemModel';
import { ActionTree } from 'vuex';
import { ItemState } from './state';
import { RootState } from '@/store';
import  ItemMutationTypes  from './mutations';
import {ItensMutationTypes} from './mutations';
import { Container, Inject } from 'typescript-ioc';
import  ItemService  from '@/Service/Itens/ItemService';
import CategoriaService from '@/Service/Itens/CategoriaService';
import TipoService from '@/Service/Itens/TipoService';
import TipoModel from '@/Model/Itens/TipoModel';



export enum ItensActionTypes {
  OBTER_CATEGORIAS_ITEM = 'OBTER_CATEGORIAS_ITEM',
  SALVAR_CATEGORIA_ITEM = 'SALVAR_CATEGORIA_ITEM',
  EDITAR_CATEGORIA_ITEM = 'EDITAR_CATEGORIA_ITEM',
  REMOVER_CATEGORIA_ITEM = 'REMOVER_CATEGORIA_ITEM',

  OBTER_TIPOS_ITEM = 'OBTER_TIPOS_ITEM',
  SALVAR_TIPO_ITEM = 'SALVAR_TIPO_ITEM',
  EDITAR_TIPO_ITEM = 'EDITAR_TIPO_ITEM',
  REMOVER_TIPO_ITEM = 'REMOVER_TIPO_ITEM',

  OBTER_ITENS = 'OBTER_ITENS',
  SALVAR_ITEM = 'SALVAR_ITEM',
  EDITAR_ITEM = 'EDITAR_ITEM',
  REMOVER_ITEM = 'REMOVER_ITEM',
}


const actions: ActionTree<ItemState, RootState> = {

  async [ItensActionTypes.OBTER_CATEGORIAS_ITEM]({ commit }) {
    const service = (Container.get(CategoriaService) as CategoriaService);
    const categorias = await service.obterTodasCategorias();
    commit(ItensMutationTypes.SET_CATEGORIAS_ITEM, categorias);
  },

  async [ItensActionTypes.SALVAR_CATEGORIA_ITEM]({ commit }, categoria: CategoriaModel ) {
    const service = (Container.get(CategoriaService) as CategoriaService);
    await service.salvarCategoria(categoria);
    const categorias = await service.obterTodasCategorias();
    commit(ItensMutationTypes.SET_CATEGORIAS_ITEM, categorias);
  },

  async [ItensActionTypes.EDITAR_CATEGORIA_ITEM]({ commit }, categoria: CategoriaModel ) {
    const service = (Container.get(CategoriaService) as CategoriaService);
    await service.editarCategoria(categoria);
    const categorias = await service.obterTodasCategorias();
    commit(ItensMutationTypes.SET_CATEGORIAS_ITEM, categorias);
  },

  async [ItensActionTypes.REMOVER_CATEGORIA_ITEM]({ commit }, id: number ) {
    const service = (Container.get(CategoriaService) as CategoriaService);
    await service.delete(id);
    const categorias = await service.obterTodasCategorias();
    commit(ItensMutationTypes.SET_CATEGORIAS_ITEM, categorias);
  },

  async [ItensActionTypes.OBTER_TIPOS_ITEM]({ commit }) {
    const service = (Container.get(TipoService) as TipoService);
    const tipos = await service.obterTodosTipos();
    commit(ItensMutationTypes.SET_TIPOS_ITEM, tipos);
  },

  async [ItensActionTypes.SALVAR_TIPO_ITEM]({ commit }, tipo: TipoModel) {
    const service = (Container.get(TipoService) as TipoService);
     await service.salvarTipo(tipo);
     const categorias = await service.obterTodosTipos();
    commit(ItensMutationTypes.SET_TIPOS_ITEM, categorias);
  },

  async [ItensActionTypes.EDITAR_TIPO_ITEM]({ commit }, tipo: TipoModel ) {
    const service = (Container.get(TipoService) as TipoService);
    await service.editarTipo(tipo);
    const tipos = await service.obterTodosTipos();
    commit(ItensMutationTypes.SET_TIPOS_ITEM, tipos);
  },

  async [ItensActionTypes.REMOVER_TIPO_ITEM]({ commit }, id: number) {
    const service = (Container.get(TipoService) as TipoService);
     await service.delete(id);
     const tipos = await service.obterTodosTipos();
    commit(ItensMutationTypes.SET_TIPOS_ITEM, tipos);
  },


  async [ItensActionTypes.OBTER_ITENS]({ commit }) {
    const service = (Container.get(ItemService) as ItemService);
    const itens = await service.obterTodosItens();
    commit(ItensMutationTypes.SET_ITEMS, itens);
  },

  async [ItensActionTypes.SALVAR_ITEM]({ commit }, item: ItemModel) {
    const service = (Container.get(ItemService) as ItemService);
    await service.salvarItem(item);
    const itens = await service.obterTodosItens();
    commit(ItensMutationTypes.SET_ITEMS, itens);
  },

  async [ItensActionTypes.EDITAR_ITEM]({ commit }, item: ItemModel) {
    const service = (Container.get(ItemService) as ItemService);
    await service.editarItem(item);
    const itens = await service.obterTodosItens();
    commit(ItensMutationTypes.SET_ITEMS, itens);
  },

  async [ItensActionTypes.REMOVER_ITEM]({ commit }, id: number) {
    const service = (Container.get(ItemService) as ItemService);
    await service.delete(id);
    const itens = await service.obterTodosItens();
    commit(ItensMutationTypes.SET_ITEMS, itens);
  },
};

export default actions;
