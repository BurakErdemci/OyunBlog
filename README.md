# OyunBlog Projesi - Backend (ASP.NET Core) Detaylı Açıklama

## Genel Bakış

Bu proje, modern bir oyun blogu ve forumu sunmak için **ASP.NET Core** ile geliştirilmiş, çok katmanlı (multi-layered) mimariye sahip bir web uygulamasıdır. Projede, Entity Framework Core ile SQLite veritabanı, repository ve unit of work pattern’ı, ASP.NET Core Identity ile kimlik doğrulama/rol yönetimi, DTO ve AutoMapper ile mapping, Razor Pages ve MVC Controller yapısı birlikte kullanılmıştır.

## Katmanlı Mimari

```
Solution
│
├── Core/                # Entity, DTO, Interface ve temel modeller
├── Data/                # DbContext, Repository, UnitOfWork, Migration
├── BusinessLogic/       # Servisler, iş mantığı, AutoMapper profilleri
├── MainPage/            # Sunum katmanı (Razor Pages, Controller, ViewModel)
├── Utilities/           # Yardımcı araçlar, extension'lar, mapping
```

## Temel Bileşenler ve Akış

### 1. **Entity ve DTO Yapısı (Core Katmanı)**

- **Entity’ler:** ForumTopic, ForumReply, ForumCategory, ForumTag, ForumTopicTag gibi ana modeller, ilişkili alanlar ve validasyonlarla tanımlanır.
- **DTO’lar:** Dışarıya veri taşımak için sadeleştirilmiş modeller (ör. ForumTopicDto) kullanılır.

**Örnek: ForumTopic Entity**
```csharp
public class ForumTopic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ViewCount { get; set; }
    public int ReplyCount { get; set; }
    public string? UserId { get; set; }
    public IdentityUser? User { get; set; }
    public int? CategoryId { get; set; }
    public ForumCategory? Category { get; set; }
    public ICollection<ForumReply>? Replies { get; set; }
    public ICollection<ForumTopicTag>? ForumTopicTags { get; set; }
}
```

**Örnek: ForumTopicDto**
```csharp
public class ForumTopicDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CategoryName { get; set; }
    public string UserName { get; set; }
    public int ReplyCount { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

### 2. **Veri Erişim Katmanı (Data)**

- **AppDbContext:** Tüm entity’ler için DbSet tanımları ve ilişkiler burada kurulur.
- **Repository Pattern:** Her entity için repository’ler ile temel CRUD işlemleri soyutlanır.
- **Unit of Work:** Tüm repository’leri tek noktadan yönetir, transaction bütünlüğü sağlar.

**Örnek: UnitOfWork**
```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IForumTopicRepository ForumTopicRepository => _forumTopicRepository ??= new ForumTopicRepository(_context);
    // ... diğer repository'ler
    public async Task CommitAsync() => await _context.SaveChangesAsync();
}
```

### 3. **İş Mantığı Katmanı (BusinessLogic)**

- **Service Sınıfları:** ForumService gibi servisler, repository’leri kullanarak iş mantığını ve validasyonları yönetir.
- **AutoMapper Profilleri:** Entity ile DTO arasında otomatik dönüşüm sağlar.

**Örnek: ForumService**
```csharp
public class ForumService
{
    public async Task<List<ForumTopicDto>> GetAllTopicsDtoAsync()
    {
        var topics = await _context.ForumTopics.Include(t => t.User).Include(t => t.Category).ToListAsync();
        return _mapper.Map<List<ForumTopicDto>>(topics);
    }
    // CRUD, arama, sayfalama, reply ekleme, view count artırma vb.
}
```

**Örnek: AutoMapper Profili**
```csharp
public class ForumProfile : Profile
{
    public ForumProfile()
    {
        CreateMap<ForumTopic, ForumTopicDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
    }
}
```

### 4. **Sunum Katmanı (MainPage)**

- **Razor Pages:** Forum, konu detay, konu oluşturma/düzenleme/silme gibi işlemler için PageModel ve .cshtml dosyaları.
- **Sayfalama ve Arama:** Forum ana sayfasında arama ve sayfalama query string ile yönetilir.
- **Rol Bazlı Yetkilendirme:** Admin rolüyle konu düzenleme/silme işlemleri yapılabilir.

**Örnek: Forum.cshtml.cs (PageModel)**
```csharp
public class ForumModel : PageModel
{
    public async Task OnGetAsync(string q, [FromQuery] int page = 1)
    {
        var allTopics = await _forumService.GetAllTopicsDtoAsync();
        if (!string.IsNullOrWhiteSpace(q))
            allTopics = allTopics.Where(t => t.Title.Contains(q, ...)).ToList();
        // Sayfalama işlemi
        Topics = allTopics.Skip((page - 1) * PageSize).Take(PageSize).ToList();
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _forumService.DeleteTopicAsync(id);
        return RedirectToPage("/Forum");
    }
}
```

### 5. **Kimlik Doğrulama ve Rol Yönetimi**

- **ASP.NET Core Identity:** Kullanıcı yönetimi, şifre politikası, giriş/çıkış, admin rolü oluşturma ve atama.
- **Seed İşlemi:** Uygulama başlatıldığında admin rolü ve kullanıcıya rol ataması otomatik yapılır.

**Örnek: Program.cs**
```csharp
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    var user = await userManager.FindByEmailAsync("...@gmail.com");
    if (user != null && !await userManager.IsInRoleAsync(user, "Admin"))
        await userManager.AddToRoleAsync(user, "Admin");
}
```

---

## Öne Çıkan Özellikler

- **Forum için CRUD işlemleri** (konu oluşturma, düzenleme, silme)
- **Admin yetkisiyle işlem yapma**
- **Forum başlıklarında arama ve sayfalama (pagination)**
- **DTO ve AutoMapper ile modern veri transferi**
- **Validasyon ve hata yönetimi**
- **Modern ve responsive tasarım**
- **Kodun temiz, sürdürülebilir ve genişletilebilir olması**

---



## Kurulum ve Çalıştırma(Şuan için sadece 4. madde yeterli)

 
  
1. **Migrationları ekleyin**  
   `Add migration init`
2. **Databaseyi güncelleyin:**  
   `Update Database`
3. **Projeyi Çalıştırın:**  
4. **Varsayılan admin hesabı için e-posta veya kullanıcı adı ile giriş yapın.**

---

- Proje sahibi: [Burak Emre Erdemci]




---

Proje ile ilgili Görseller:

1-Login Register Ekranları:![image](https://github.com/user-attachments/assets/ccb376f8-edfd-4d5b-b225-931f31d147f2) 
![image](https://github.com/user-attachments/assets/e69050cd-1b72-4f21-b7a4-6e74c6fbd3c0)

2-Forum Ekranı:![image](https://github.com/user-attachments/assets/737358e1-d5be-4248-a3a0-53600fe1404e)

3-API ile çekilen haber ve indirim sayfaları ![image](https://github.com/user-attachments/assets/8a534ab2-e295-446c-a3da-310fdcf304cf) 
![image](https://github.com/user-attachments/assets/2f9f0305-11a2-4d7d-abbd-d3a5a1937b07)

4-Ana sayfa: ![image](https://github.com/user-attachments/assets/b2ad3d2a-378c-4570-98fd-e1bd5d9072b0)






