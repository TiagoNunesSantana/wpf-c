using ClinicLab.App.Data;
using ClinicLab.App.Models;

namespace ClinicLab.App.Repositories;

public class PacienteRepository
{
    private readonly AppDbContext _context = new();

    public List<Paciente> Listar()
    {
        return _context.Pacientes.ToList();
    }

    public void Salvar(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);

        _context.SaveChanges();
    }
}