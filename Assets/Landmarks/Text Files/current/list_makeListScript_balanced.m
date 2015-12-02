%% Script to randomize misaligned trials for JRD task from list.txt in Landmarks

% NOTE: To make your life easier, just re-save the list as a .xlxs file format

%cd('/Users/mjstarrett/repos/LandMarksOculus/Assets/Landmarks/Text Files/current/');

% From the Home tab:
%     - Select 'Import Data'
%     - Choose 'list_bigCityCyberith.xlsx'
%     - Choose 'Cell Array' format for the imported data
%     - Select ALL
%     - Import

rng shuffle; % set the random number generator to the current time (otherwise produces same list each time)

noSpace = listbigCityCyberithALL(1:2:end); %remove the blank spaces between Questions

%Generate some random JRD lists (pulling 84 of the 264 possible
%misaligned questions and randomizing with the 84 aligned)
for sub = 301:320

% select and randomize 84 aligned trials
aligned = noSpace(1:84); %separate Aligned trials
r = randperm(length(aligned));
aligned_rand_final = aligned(r);
    
% select and randomize 84 misaligned trials
misaligned = noSpace(85:end); %separate Misaligned trials
p = randperm(length(misaligned)); %create a randomization index
misaligned_rand = misaligned(p); %new variable with misaligned trials randomized according to p index (see line above)
misaligned_rand_final = misaligned_rand(1:84); %Take just the first 84 randomized trials (equal to # of aligned trials) 

% Create balanced blocks and then randomize within them
block = {};
block_rand = {};
for i = 1:6
    block(i,1:14)   =    aligned_rand_final((i*14 - 13):(i*14));
    block(i,15:28)  = misaligned_rand_final((i*14 - 13):(i*14));
    rand = randperm(28);
    block_rand(i,1:28) = block(i,rand);
end
final_combined = reshape(block_rand(:,:)',[168,1]);

% make each row into a cell AND SUPPRESSES TRAILING WHITESPACE!
list_bigCity_cyberith_final = strcat(final_combined); 
fid = fopen(['list_bigCityCyberith_s' num2str(sub) '.txt'],'w');
for r=1:size(list_bigCity_cyberith_final,1)
    fprintf(fid,'%s\n',final_combined{r,:},'');
end
fclose(fid);
%save(['list_bigCityCyberith_s' num2str(sub) '.txt','final_combined') % save it as a text file
end


% You will have to go press enter on each line to get it back into the same
% format as the original (or just leave it without line spaces; they really
% just make it look pretty and add extra lines of code to work with (see
% above).





