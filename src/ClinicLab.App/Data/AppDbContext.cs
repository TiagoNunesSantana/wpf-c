using ClinicLab.App.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicLab.App.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Paciente> Pacientes => Set<Paciente>();

    public DbSet<Exame> Exames => Set<Exame>();
}