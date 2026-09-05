using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class ActorMapper
    {
        public static ActorDto ToActorDto(this Actor actor)
        {
            return new ActorDto
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                FullName = $"{actor.FirstName} {actor.LastName}"
            };
        }

        public static List<ActorDto> ToActorDtoList(this IEnumerable<Actor> actors)
            => actors.Select(actor => actor.ToActorDto()).ToList();

        public static Actor ToActor(this AddActorDto dto)
        {
            return new Actor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }
    }
}
