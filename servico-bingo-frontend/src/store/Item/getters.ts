import { GetterTree } from 'vuex';
import { ItemState } from './state';
import { RootState } from '@/store';

export enum ResumoGetterTypes {
  TURMA_SELECIONADA = 'TURMA_SELECIONADA',
}

const getters: GetterTree<ItemState, RootState> = {
  [ResumoGetterTypes.TURMA_SELECIONADA](state) {
    return state.itens;
  },
};

export default getters;
