using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//Mapping de propriedades no banco
namespace Infrastructure.Migrations
{
    //Indica que ela é uma classe de configuração do EF para a classe Usuario
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        //Como vai ser configurado no banco de dados é o map
        //De-para ta tabela Usuario para classe no sistema Usuario
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Ef DESIGN é usado para desenhar para o banco(.toTable .HasKey ...)

            //Nome tabela
            builder.ToTable("Usuario");

            //Campo Id
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnType("BIGINT");

            //Campo Nome
            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(80)
                   .HasColumnName("nome")
                   .HasColumnType("VARCHAR(80)");

            //Campo sENHA
            builder.Property(x => x.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("SENHA")
                    .HasColumnType("VARCHAR(30)");

            //Campo Email
            builder.Property(x => x.Email)
                       .IsRequired()
                       .HasMaxLength(100)
                       .HasColumnName("email")
                       .HasColumnType("VARCHAR(100)");
        }
    }
}
