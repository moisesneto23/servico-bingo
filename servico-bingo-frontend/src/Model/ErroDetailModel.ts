export default class ErroDetailModel {
    public code!: string;
    public message!: string;
    public target?: string;
    public details?: ErroDetailModel[];
  }
  