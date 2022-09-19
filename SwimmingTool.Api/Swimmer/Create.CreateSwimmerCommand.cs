using System.ComponentModel.DataAnnotations;

namespace SwimmingTool.Api.Swimmer;

public record CreateSwimmerCommand([Required]string Name, string category);