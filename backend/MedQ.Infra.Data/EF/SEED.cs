using MedQ.Infra.Data.Context;
using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQ.Infra.Data.EF
{
    public static class SEED
    {
        public static void Popular(MedQContext context)
        {
            if(context.AgendamentoDisponiveis.Count().Equals(0))
            {
                context.AgendamentoDisponiveis.Add(new AgendamentoDisponiveis(1, 1, 1, 1, DateTime.Now.Date, DateTime.Now));
            }

            if (context.Consultas.Count().Equals(0))
            {
                context.Consultas.Add(new Consultas(1, 1, 1, 1, "123", "inativo", DateTime.Now.Date, DateTime.Now));
                context.Consultas.Add(new Consultas(4, 1, 1, 1, "123", "ativo", DateTime.Now.Date, DateTime.Now));
            }

            if(context.Especialidade.Count().Equals(0))
            {
                context.Especialidade.Add(new Especialidade(1, "Ortopedia", "É a parte da medicina que estuda e trata as doenças do sistema osteomuscular, locomoção, crescimento, deformidades e as fraturas."));
                context.Especialidade.Add(new Especialidade(2, "Cardiologia", "Aborda as doenças relacionadas com o coração e sistema vascular."));
                context.Especialidade.Add(new Especialidade(3, "Gastroenterologia", "É o estudo, diagnóstico, tratamento e prevenção de doenças relacionadas ao aparelho digestivo, desde erros inatos do metabolismo, doença do trato gastrointestinal, doenças do fígado e cânceres."));
                context.Especialidade.Add(new Especialidade(4, "Alergia e Imunologia", "Diagnóstico e tratamento das doenças alérgicas e do sistema imunológico"));
                context.Especialidade.Add(new Especialidade(5, "Anestesiologia", "Área da Medicina que envolve o tratamento da dor, a hipnose e o manejo intensivo do paciente sob intervenção cirúrgica ou procedimentos"));
                context.Especialidade.Add(new Especialidade(6, "Angiologia", "Área da medicina que estuda o tratamento das doenças do aparelho circulatório"));
                context.Especialidade.Add(new Especialidade(7, "Cancerologia", "É a especialidade que trata dos tumores malignos ou câncer"));
                context.Especialidade.Add(new Especialidade(8, "Cirurgia Cardiovascular", "Tratamento cirúrgico de doenças do coração"));
                context.Especialidade.Add(new Especialidade(9, "Cirurgia da Mão", "Cuida das doenças das mãos e dos punhos, incluindo os ossos, articulações, tendões, músculos, nervos, vasos e pele"));
                context.Especialidade.Add(new Especialidade(10, "Cirurgia Geral", "Área que engloba todas as áreas cirúrgicas, sendo também subdividida"));
                context.Especialidade.Add(new Especialidade(11, "Cirurgia Plástica", "Correção das deformidades, malformações ou lesões que comprometem funções dos órgãos através de cirurgia de caráter reparador ou cirurgias estéticas"));
                context.Especialidade.Add(new Especialidade(12, "Dermatologia", "É o estudo da pele anexos (pelos, glândulas), tratamento e prevenção das doenças"));
                context.Especialidade.Add(new Especialidade(13, "Endoscopia", "Esta especialidade médica ocupa-se do estudo dos mecanismo fisiopatológicos, diagnóstico e tratamento de enfermidades passíveis de abordagem por procedimentos endoscópicos e minimamente invasivos"));
                context.Especialidade.Add(new Especialidade(14, "Neurocirurgia", "Atua no tratamento de doenças do sistema nervoso central e periférico passíveis de abordagem cirúrgica"));
                context.Especialidade.Add(new Especialidade(15, "Psiquiatria", "É a parte da medicina que previne e trata ao transtornos mentais e comportamentais"));
            }

            if (context.Estabelecimento.Count().Equals(0))
            {
                context.Estabelecimento.Add(new Estabelecimento(1, "Hospital Águas Claras", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "BRASILIA", "AGUAS CLARAS", "DF", "-15.8464379", "-48.0300584", DateTime.Now,
                    "https://aquiaguasclaras.com.br/wp-content/uploads/2019/07/20170201_083431.jpg", 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(4, "Hospital de Base do Distrito Federal", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.8003300", "-47.8884235", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(5, "Hospital de Apoio de Brasília", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.7583202", "-47.9154930", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(6, "Hospital Materno Infantil Dr. Antônio Lisboa", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "", "", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(7, "Hospital da Criança de Brasília", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.7589517", "-47.9174626", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(8, "Hospital São Vicente de Paulo", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-22.9158221", "-43.2150277", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(9, "Hospital Regional da Asa Norte", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.7848220", "-47.8828378", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(10, "Hospital Regional de Brazlândia", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.6750780", "-48.2036740", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(11, "Hospital Regional de Ceilândia", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.8151989", "-48.0959864", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(12, "Hospital Regional do Gama", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-16.0232990", "-48.0694454", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(13, "Hospital Regional do Guará", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.8181587", "-47.9862626", DateTime.Now,
                    null, 1, 1));
                context.Estabelecimento.Add(new Estabelecimento(14, "Hospital da Região Leste", "70297-400",
                    "R. Arariba, 5 - Águas Claras", "", "NOVA BRASILIA", "AGUAS CLARAS", "DF", "-15.7814329", "-47.7818247", DateTime.Now,
                    null, 1, 1));
            }

            if(context.Fila.Count().Equals(0))
            {
                context.Fila.Add(new Fila(10, 10, null, DateTime.Now, 1, 1, 1));
                context.Fila.Add(new Fila(11, 10, "Fial x", DateTime.Now, 1, 1, 1));
            }

            if (context.Medico.Count().Equals(0))
            {
                context.Medico.Add(new Medico(1, "Doctor who", "052458445", 1, 1));
            }

            if(context.MinhasConsulta.Count().Equals(0))
            {
                context.MinhasConsulta.Add(new MinhasConsulta(1, "Consulta X", "Consulta de retorno de exame", "", "Pedido Medico", "txt123", "Doctor Who", DateTime.Now.Date, DateTime.Now, "Ativo", "", 1, 1));
            }

            if (context.Socio.Count().Equals(0))
            {
                context.Socio.Add(new Socio(1, "Administrador", "12345678901", "Masculino", "admin@gmail.com",
                    "25d55ad283aa400af464c76d713c07ad", "Rua dos idiotas", "Número 1", "BRASILIA", "AGUAS CLARAS", "DF", DateTime.Now, null, null, null, null, true));

                context.Socio.Add(new Socio(2, "Fulano de tal", "12345678901", "Masculino", "fulano.de.tal@gmail.com",
                    "e10adc3949ba59abbe56e057f20f883e", "Rua dos tolos", "Número 0", "BRASILIA", "AGUAS CLARAS", "DF", DateTime.Now, null, null, null, null, false));
            }

            if (context.Telefone.Count().Equals(0))
            {
                context.Telefone.Add(new Telefone(3, "11", "89558874", 1, 1));
            }

            if (context.TipoAtendimento.Count().Equals(0))
            {
                context.TipoAtendimento.Add(new TipoAtendimento(1, "PRONTO SOCORRO"));
                context.TipoAtendimento.Add(new TipoAtendimento(2, "PRONTO ATENDIMENTO"));
            }

            if (context.TipoEstabelecimento.Count().Equals(0))
            {
                context.TipoEstabelecimento.Add(new TipoEstabelecimento(1, "HOSPITAL 24HRS"));
                context.TipoEstabelecimento.Add(new TipoEstabelecimento(2, "CLINICA"));
            }

            context.SaveChanges();
        }
    }
}
