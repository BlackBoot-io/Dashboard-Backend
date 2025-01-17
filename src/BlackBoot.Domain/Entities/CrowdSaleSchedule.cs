﻿#nullable disable
namespace BlackBoot.Domain.Entities;

[Table(nameof(CrowdSaleSchedule), Schema = nameof(EntitySchema.Base))]
public class CrowdSaleSchedule : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CrowdSaleScheduleId { get; set; }

    public int TokenForSale { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    [Required, MaxLength(50)]
    public string Title { get; set; }

    public bool IsActive { get; set; }

    public int MinimumBuy { get; set; }

    public int CurrentInvestment { get; set; }

    public int InvestmentGoal { get; set; }

    public int BonusCount { get; set; }

    [Column(TypeName = "decimal(21,9)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(21,9)")]
    public decimal CurrentIncreaseRate { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [NotMapped]
    public int PeriodDay => (From - To).Days;

    public bool InvestmentIsAvailable() => From <= DateTime.Now && InvestmentGoal > CurrentInvestment;

    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; }
}