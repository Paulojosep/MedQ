using MedQ.Application.IO;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class MinhasConsultaRepository : IMinhasConsultaRepository
    {
        private MedQContext _minhasConsultaContext;

        public MinhasConsultaRepository(MedQContext context)
        {
            _minhasConsultaContext = context;
        }

        public async Task<IEnumerable<MinhasConsulta>> GetAllAsyns()
        {
            var resultado = await _minhasConsultaContext.MinhasConsulta.ToListAsync();
            return resultado;
        }

        public async Task<MinhasConsulta> GetFinishedMensagensAsync(int socioId)
        {
            var consulta = from m in _minhasConsultaContext.MinhasConsulta where m.SocioId == socioId select m;
            return await consulta.FirstOrDefaultAsync();

        }

        public async Task<bool> CreateMyConsultationAsync(MinhasConsultas2 minhasConsulta)
        {
            await _minhasConsultaContext.Database.ExecuteSqlRawAsync($@"INSERT INTO tb_minhas_consultas 
                    (titulo, resumo, texto, pedido, senha, profissional, data, hora, status, finished, fk_consultas_id, fk_socio_id) 
                    VALUES 
                    ({minhasConsulta.Estabelecimento.Nome},{minhasConsulta.Especialidade.Nome},{null},{minhasConsulta.Pedido},{minhasConsulta.consultas.Senha},{minhasConsulta.Medico.Nome},{minhasConsulta.data},{minhasConsulta.hora},{minhasConsulta.status},{0},{minhasConsulta.consulta_id},{minhasConsulta.socio_id})");
            await _minhasConsultaContext.SaveChangesAsync();
            return true;
        }

        public async Task<MinhasConsulta> UpdateMyConsultationAsync(MinhasConsulta minhasConsulta)
        {
            _minhasConsultaContext.Database.ExecuteSqlRaw($@"UPDATE tb_minhas_consultas SET status = '{minhasConsulta.Status}', 
                                                            finished = {minhasConsulta.Finished} 
                                                            WHERE fk_consultas_id = {minhasConsulta.ConsultaId}");
            await _minhasConsultaContext.SaveChangesAsync();
            return minhasConsulta;
        }

        public async Task DeleteMyConsultationAsync(int id)
        {
            await _minhasConsultaContext.Database.ExecuteSqlRawAsync($@"DELETE FROM tb_minhas_consultas WHERE id = {id}");
            await _minhasConsultaContext.SaveChangesAsync();
        }
    }
}
