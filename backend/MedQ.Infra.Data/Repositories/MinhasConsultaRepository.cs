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
        private ApplicationDbContext _minhasConsultaContext;

        public MinhasConsultaRepository(ApplicationDbContext context)
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

        public async Task<MinhasConsulta> CreateMyConsultationAsync(MinhasConsulta minhasConsulta)
        {
            _minhasConsultaContext.Add(minhasConsulta);
            await _minhasConsultaContext.SaveChangesAsync();
            return minhasConsulta;
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
