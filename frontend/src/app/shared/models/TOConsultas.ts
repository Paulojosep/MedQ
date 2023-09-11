import { TOAgendamentoDisponivel } from "./TOAgendamentoDisponivel";
import { TOEspecialidade } from "./TOEspecialidade";
import { TOEstabelecimento } from "./TOEstabelecimento";
import { TOMedico } from "./TOMedico";
import { TOSocio } from "./TOSocio";


export interface TOConsultas {
    id: number;
    data: string;
    hora: string;
    status: string;
    senha: string;
    agendamentoId: number;
    estabelecimentoId: number;
    socioId: number;

    socio: TOSocio;
    agendamento: TOAgendamentoDisponivel;
    estabelecimento: TOEstabelecimento;
}

export interface ConsultasPorSocioOutput {
    codigo: number;
    medico: string;
    especialidade: string;
    consultas: string;
    data: string;
    hora: string;
    status: string;
    senha: string;
}

export interface MinhasConsultaInput {
    senha: string;
    profissional_nome: string;
    data: string;
    hora: string;
    status: string;
    consulta_id: number;
    socio_id: number;
    estabelecimento_nome: string;
    especialidade_nome: string;
    pedido: string;
    consultas: TOConsultas;
    agendamento: TOAgendamentoDisponivel;
    estabelecimento: TOEstabelecimento;
    especialidade: TOEspecialidade;
    medico: TOMedico;
}