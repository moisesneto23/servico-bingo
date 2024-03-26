import { GetterTree } from 'vuex';
import { ProdutoState } from './state';
import { RootState } from '@/store';

export enum ResumoGetterTypes {
  TURMA_SELECIONADA = 'TURMA_SELECIONADA',
}

const getters: GetterTree<ProdutoState, RootState> = {
  [ResumoGetterTypes.TURMA_SELECIONADA](state) {
    return state.produtos;
  },
};

export default getters;
