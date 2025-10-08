using EcommerceWithPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAdjustment> AccountAdjustments { get; set; }
        public DbSet<Adjustment> Adjustments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Biller> Billers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<PSize> PSizes { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<DefaultCourier> DefaultCouriers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DiscountPlanCustomer> DiscountPlanCustomers { get; set; }
        public DbSet<DiscountPlanDiscount> DiscountPlanDiscounts { get; set; }
        public DbSet<DiscountPlan> DiscountPlans { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DsoAlert> DsoAlerts { get; set; }
        public DbSet<EcommerceSetting> EcommerceSettings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExternalService> ExternalServices { get; set; }
        public DbSet<FailedJob> FailedJobs { get; set; }
        public DbSet<FaqCategory> FaqCategories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<FraudCheckLog> FraudCheckLogs { get; set; }
        public DbSet<FraudCheck> FraudChecks { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<GiftCardRecharge> GiftCardRecharges { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<HrmSetting> HrmSettings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LeadNote> LeadNotes { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        public DbSet<LeadStatus> LeadStatuses { get; set; }
        public DbSet<LeadSubject> LeadSubjects { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<MailSetting> MailSettings { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageWidget> PageWidgets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentGateway> PaymentsGateways { get; set; }
        public DbSet<PaymentWithCheque> PaymentsWithCheques { get; set; }
        public DbSet<PaymentWithCreditCard> PaymentsWithCreditCards { get; set; }
        public DbSet<PaymentWithGiftCard> PaymentsWithGiftCards { get; set; }
        public DbSet<PaymentWithPaymentGateway> PaymentsWithPaymentGateways { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PosSetting> PosSettings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPurchase> ProductPurchases { get; set; }
        public DbSet<ProductQuotation> ProductQuotations { get; set; }
        public DbSet<ProductReturn> ProductReturns { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<ProductTransfer> ProductTransfers { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
        public DbSet<ProductAdjustment> ProductAdjustments { get; set; }
        public DbSet<ProductBatch> ProductBatchs { get; set; }
        public DbSet<ProductImei> ProductImeis { get; set; }
        public DbSet<PurchaseProductReturn> PurchaseProductReturn { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ReturnPurchase> ReturnPurchases { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<RewardPointSetting> RewardPointSettings { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ShippingCharge> ShippingCharges { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SmsConfig> smsConfigs { get; set; }
        public DbSet<SmsGateway> SmsGateways { get; set; }
        public DbSet<SmsTemplate> smsTemplates { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<StockCount> StockCounts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivityLog> UsersActivityLogs { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WebhookSetting> WebhookSettings { get; set; }
        public DbSet<Widget> Widgets { get; set; }

    }
}
