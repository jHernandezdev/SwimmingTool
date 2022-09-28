using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SwimmingTool.Application.Swimmers.Commands;

public static class V1
{
  public record CreateSwimmerCommand([Required] string Name, string category): IRequest<SwimmerCreateRespone>;
  public record SwimmerCreateRespone(int Id, string Name, string Category);
}