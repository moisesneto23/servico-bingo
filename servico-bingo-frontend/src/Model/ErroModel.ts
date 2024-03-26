import ErroDetailModel from './ErroDetailModel';

export default class ErroModel {
  public code!: number;
  public message!: string;
  public details?: ErroDetailModel[] = [];
}
