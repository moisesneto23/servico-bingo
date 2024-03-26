import  Login  from '@/Model/Login';
import  InformacoesEmpresa  from '@/Model/InformacoesEmpresa';
import {EmpresaRepository} from '@/Repository/EmpresaRepository';
import EmpresaModel from '@/Model/Empresa/EmpresaModel';
import { Container,Inject } from 'typescript-ioc';
import { AxiosResponse } from 'axios';

export default class EmpresaService {

    @Inject
    private empresa!: EmpresaRepository;

    public async obterTodasEmpresas(): Promise<EmpresaModel[]> {
        return await this.empresa.obterEmpresas();
    }

    public async obterInformacoesEmpresa( login: Login): Promise<InformacoesEmpresa> {
        return await this.empresa.obterInformacoesEmpresa(login);
    }

};