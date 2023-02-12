import { IMinhasConsulta } from "./IMinhasConsulta";

export class IConsultas {
    Id: number;
    Data: Date;
    Hora: Date;
    Status: string;
    Senha: string;
    AgendamentoId: number;
    EstabelecimentoId: number;
    SocioId: number;
    minhasConsultas: IMinhasConsulta[];
}