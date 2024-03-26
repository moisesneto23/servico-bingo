import { GetterTree } from 'vuex';
import { GlobalState } from './state';
import { RootState } from '@/store';

export enum GlobalGetterTypes {
  OBTENDO_INFORMACOES = 'OBTENDO_INFORMACOES',
}

const getters: GetterTree<GlobalState, RootState> = {


};

export default getters;
