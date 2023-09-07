using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator() 
        {
            RuleFor(deteleNoteCommand =>
                deteleNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deteleNoteCommand =>
                deteleNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
