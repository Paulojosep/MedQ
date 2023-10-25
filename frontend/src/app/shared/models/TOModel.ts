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

export interface TOConsultaOutput {
    imagem: string;
    nomeHospital: string;
    dataHora: string;
    status: string;
    senha: string;
    cep: string;
    endereco: string;
    estado: string;
}

export interface TOEspecialidade {
    id: number;
    nome: string;
    descricao: string;
}

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

export interface TOMedico {
    nome: string;
    cpf: string;
    especialidadeId: number;
    estabelecimentoId: number;
}

export interface TOSocio {
    id: number;
    nome: string;
    cPF: string;
    uF: string;
    sexo: string;
    email: string;
    senha: string;
    endereco: string;
    complemento: string;
    cidade: string;
    bairro: string;
    data_Cadastro: string;
    image: string;
    codigoVerificacao: string;
    idGoogle: string;
    tipo: string;
    ehAdmin: boolean;
}

export interface TOTelefone {
    id: number;
    DDD: string;
    numero: string;
    estabelecimentoId: number;
    socioId: number;
}

export interface TOTipoEstabelecimento {
    id: number;
    tipo: string;
}

export interface TOUsuarioLogado {
    id: number;
    nome: string;
    email: string;
    acesso: string;
    token: string;
}