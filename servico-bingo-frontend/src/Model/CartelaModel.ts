import { CartelaNumeroBingoModel } from "./CartelaNumeroBingoModel";

export class CartelaModel {
    public id!: number;
    public nome!: string;
    public cpf!: string;
    public cartelaNumeroBingos: CartelaNumeroBingoModel[] = [];
    }