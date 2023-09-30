import { TOSocio } from "./TOSocio";
import { TOTipoEstabelecimento } from "./TOTipoEstabelecimento";

export interface TOEstabelecimento {
    id: number;
    nome: string;
    cep: string;
    endereco: string;
    complemento: string;
    cidade: string;
    bairro: string;
    estado: string;
    data_Cadastro: string;
    image: string;
    tipoEstabelecimentoId: number;
    socioId: number;

    tipoEstabelecimento: TOTipoEstabelecimento;
    socio: TOSocio;
}