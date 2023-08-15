import { TOMedico } from "./TOMedico";

export interface TOAgendamentoDisponivel {
    id: number;
    data: string;
    hora: string;
    disponibilidade: number;
    medicoId: number;
    estabelecimentoId: number;
    medico: TOMedico;
}

export interface AgendamentoDisponivelInput {
    estabelecimentoId: number;
    especialidadeId: number;
    data: string;
    horaInicio: string;
    horaFim: string;
}