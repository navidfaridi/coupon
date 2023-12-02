using Microsoft.EntityFrameworkCore;
using Noyanet.Coupon.MsSql.Models;

namespace Noyanet.Coupon.MsSql;

public partial class CouponDbContext : DbContext
{

	public CouponDbContext(DbContextOptions<CouponDbContext> options)
	: base(options)
	{
	}

	public virtual DbSet<CouponHistory> CouponHistories { get; set; }
	public virtual DbSet<CouponInfo> CouponInfos { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CouponHistory>(entity =>
		{
			entity.ToTable("CouponHistory");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CouponCode)
				.HasMaxLength(10)
				.IsUnicode(false);
			entity.Property(e => e.Created).HasColumnType("datetime");
			entity.Property(e => e.ServiceOrgin)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.UserId)
				.HasMaxLength(50)
				.IsUnicode(false);

			entity.HasOne(d => d.CouponCodeNavigation).WithMany(p => p.CouponHistories)
				.HasForeignKey(d => d.CouponCode)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_CouponHistory_CouponInfo");
		});

		modelBuilder.Entity<CouponInfo>(entity =>
		{
			entity.ToTable("CouponInfo");
			entity.HasKey(e => e.Code);			

			entity.HasIndex(e => e.Id, "IX_CouponInfo_id").IsUnique();

			entity.HasIndex(e => e.UniqueId, "IX_CouponInfo_uniqueId").IsUnique();

			entity.Property(e => e.Code)
				.HasMaxLength(10)
				.IsUnicode(false);
			entity.Property(e => e.Created).HasColumnType("datetime");
			entity.Property(e => e.ExpireDate).HasColumnType("datetime");
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.RowVersion)
				.IsRowVersion()
				.IsConcurrencyToken();
			entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

