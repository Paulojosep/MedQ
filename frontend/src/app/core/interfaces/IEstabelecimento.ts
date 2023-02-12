export interface IEstabelecimento {
    Id: number;
    Nome: string;
    CEP: string;
    Endereco: string;
    Complemento: string;
    Cidade: string;
    Bairro: string;
    Estado: string;
    DataCadastro: Date;
    Image: string;
    TipoEstabelecimentoId: number;
    SocioId: number;
};