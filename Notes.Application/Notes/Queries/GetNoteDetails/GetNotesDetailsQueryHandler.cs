﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeption;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNotesDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNotesDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (dbContext, mapper) = (_dbContext, _mapper);
        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.
                FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
