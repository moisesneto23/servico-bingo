import TipoModel from '@/Model/Itens/TipoModel';
import { Dimencao } from "../Enum/DimencaoEnum";
import { DirecaoCalculo } from "../Enum/DirecaoCalculoEnum";
import ItemProdutoModel from '../Produtos/ItemProdutoModel';
export default class ItemModel {
    public  id! : number;
    public  nome! : string;
    public  dataLog !: Date;
    public  usuarioLog !: string;
    public  tipoItemId !: number;
    public  orcamentoCliente_id!: number;
    public valorVenda !: number;
    public valorCompra!: number;
    public dimencaoId!: Dimencao;
    public direcaoCalculoId!: DirecaoCalculo;// 1 é largura, 2 é altura e 3 é profundidade
    public tipoItem!: TipoModel;
    public itemProduto!: ItemProdutoModel;
}